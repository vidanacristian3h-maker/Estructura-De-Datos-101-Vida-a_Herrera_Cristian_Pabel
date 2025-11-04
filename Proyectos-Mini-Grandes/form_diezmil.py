# form_diezmil.py
import tkinter as tk
from tkinter import ttk, messagebox
import threading, math
import matplotlib.pyplot as plt
from matplotlib.backends.backend_tkagg import FigureCanvasTkAgg
import ordenamientos as od

PAGE_SIZE = 1000  # paginación para no saturar la GUI

class FrmDiezMil(tk.Toplevel):
    def __init__(self, master=None):
        super().__init__(master)
        self.title("10,000 Datos")
        self.geometry("1300x720")
        self.configure(bg="white")
        self.datos_originales = []
        self.tipo = tk.StringVar(value="ordenado")
        self.page = 0
        self.total_pages = 0
        self.tiempos = []
        self._create_widgets()

    def _create_widgets(self):
        top = tk.Frame(self, bg="white"); top.pack(fill="x", padx=10, pady=8)
        tk.Button(top, text="Generar Datos", command=self.generar_datos, width=16).pack(side="left", padx=6)
        tk.Button(top, text="Ordenar", command=self.run_thread, width=14).pack(side="left", padx=6)
        tk.Button(top, text="Graficar / Generar Otro Random", command=self.graficar_o_generar, width=26).pack(side="left", padx=6)
        tk.Button(top, text="Regresar", command=self.close, width=12).pack(side="left", padx=6)

        rb = tk.Frame(top, bg="white"); rb.pack(side="left", padx=20)
        tk.Radiobutton(rb, text="Ordenado", variable=self.tipo, value="ordenado", bg="white").pack(anchor="w")
        tk.Radiobutton(rb, text="Medio Ordenado", variable=self.tipo, value="medio", bg="white").pack(anchor="w")
        tk.Radiobutton(rb, text="Inverso", variable=self.tipo, value="inverso", bg="white").pack(anchor="w")

        self.status_lbl = tk.Label(self, text="Listo", bg="white"); self.status_lbl.pack(anchor="w", padx=12, pady=4)

        central = tk.Frame(self, bg="white"); central.pack(fill="both", expand=True, padx=10, pady=6)
        left = tk.Frame(central, bg="white"); left.pack(side="left", fill="both", expand=True)
        tk.Label(left, text="Datos (paginado)", bg="white").pack(anchor="w")
        self.tree_data = ttk.Treeview(left, columns=("idx","val"), show="headings", height=20)
        self.tree_data.heading("idx", text="Índice"); self.tree_data.heading("val", text="Valor")
        self.tree_data.column("idx", width=90); self.tree_data.column("val", width=150)
        self.tree_data.pack(side="left", fill="both", expand=True)
        ttk.Scrollbar(left, orient="vertical", command=self.tree_data.yview).pack(side="left", fill="y")

        pg = tk.Frame(left, bg="white"); pg.pack(fill="x", pady=6)
        self.btn_prev = tk.Button(pg, text="<< Anterior", command=self.prev_page, state="disabled"); self.btn_prev.pack(side="left", padx=6)
        self.page_lbl = tk.Label(pg, text="Página 0/0", bg="white"); self.page_lbl.pack(side="left", padx=6)
        self.btn_next = tk.Button(pg, text="Siguiente >>", command=self.next_page, state="disabled"); self.btn_next.pack(side="left", padx=6)

        mid = tk.Frame(central, bg="white", width=320); mid.pack(side="left", fill="y", padx=8)
        tk.Label(mid, text="Tiempos (ms)", bg="white").pack(anchor="w")
        self.tree_times = ttk.Treeview(mid, columns=("metodo","tiempo"), show="headings", height=20)
        self.tree_times.heading("metodo", text="Método"); self.tree_times.heading("tiempo", text="Tiempo (ms)")
        self.tree_times.column("metodo", width=180); self.tree_times.column("tiempo", width=100)
        self.tree_times.pack(side="left", fill="y")
        ttk.Scrollbar(mid, orient="vertical", command=self.tree_times.yview).pack(side="left", fill="y")
        self.tree_times.tag_configure('fast', background='#c7f0c4'); self.tree_times.tag_configure('slow', background='#f6c2c2'); self.tree_times.tag_configure('normal', background='white')

        right = tk.Frame(central, bg="white"); right.pack(side="left", fill="both", expand=True)
        tk.Label(right, text="Gráfica de tiempos", bg="white").pack(anchor="w")
        self.fig, self.ax = plt.subplots(figsize=(6,4))
        self.canvas = FigureCanvasTkAgg(self.fig, master=right); self.canvas.get_tk_widget().pack(fill="both", expand=True)

    def generar_datos(self):
        n = 10000; max_val = 100000
        self.datos_originales = [od.rand.randint(1, max_val) for _ in range(n)]
        self.page = 0; self.total_pages = math.ceil(len(self.datos_originales)/PAGE_SIZE)
        self._update_pagination_buttons(); self._mostrar_pagina(); self._clear_tiempos_chart()
        messagebox.showinfo("Generar", "✅ Nuevos datos generados correctamente (10,000 datos).")

    def _update_pagination_buttons(self):
        if self.total_pages <= 1:
            self.btn_prev.config(state="disabled"); self.btn_next.config(state="disabled")
        else:
            self.btn_prev.config(state="normal" if self.page>0 else "disabled")
            self.btn_next.config(state="normal" if self.page < self.total_pages-1 else "disabled")

    def _mostrar_pagina(self):
        self.tree_data.delete(*self.tree_data.get_children())
        if not self.datos_originales:
            self.page_lbl.config(text="Página 0/0"); return
        start = self.page * PAGE_SIZE; end = min(start + PAGE_SIZE, len(self.datos_originales))
        for i in range(start, end):
            self.tree_data.insert("", "end", values=(i+1, self.datos_originales[i]))
        self.page_lbl.config(text=f"Página {self.page+1}/{self.total_pages}"); self._update_pagination_buttons()

    def next_page(self): 
        if self.page < self.total_pages-1: self.page += 1; self._mostrar_pagina()
    def prev_page(self): 
        if self.page > 0: self.page -= 1; self._mostrar_pagina()

    def run_thread(self):
        t = threading.Thread(target=self._ejecutar); t.daemon = True; t.start()

    def _ejecutar(self):
        if not self.datos_originales:
            self.generar_datos()

        tipo = self.tipo.get()
        base = self.datos_originales.copy()
        if tipo == "ordenado":
            base.sort()
        elif tipo == "medio":
            base = od.medio_ordenado(base)
        else:
            base.sort(); base.reverse()

        # Actualizar vista con arreglo pedido
        self.datos_originales = base
        self.page = 0; self.total_pages = math.ceil(len(self.datos_originales)/PAGE_SIZE)
        self.after(0, self._mostrar_pagina)

        metodos = [
            ("QuickSort", od.mapa_metodos["QuickSort"]),
            ("MergeSort", od.mapa_metodos["MergeSort"]),
            ("HeapSort", od.mapa_metodos["HeapSort"]),
            ("BucketSort", od.mapa_metodos["BucketSort"]),
            ("RadixSort", od.mapa_metodos["RadixSort"]),
            ("Burbuja", od.mapa_metodos["Burbuja"]),
            ("Inserción", od.mapa_metodos["Inserción"]),
            ("Selección", od.mapa_metodos["Selección"]),
        ]

        resultados = []
        self.after(0, lambda: self.status_lbl.config(text="Ejecutando algoritmos..."))

        # avisar al usuario (opcional) si desea continuar con métodos O(n^2)
        if not messagebox.askyesno("Advertencia", "Algunos métodos (Burbuja, Inserción, Selección) tardarán mucho para 10k. ¿Deseas continuar?"):
            self.after(0, lambda: self.status_lbl.config(text="Cancelado por usuario"))
            return

        for nombre, funcion in metodos:
            temp = base.copy()
            tms = od.medir_tiempo_ms(funcion, temp)
            resultados.append((nombre, float(tms) if isinstance(tms, float) else tms))
            self.after(0, lambda r=resultados.copy(): self._mostrar_tiempos_parciales(r))

        resultados.sort(key=lambda x: (float(x[1]) if isinstance(x[1], (int,float)) else float('inf')))
        self.tiempos = resultados
        self.after(0, self._mostrar_tiempos_final)
        self.after(0, lambda: self.status_lbl.config(text="Listo"))

    def _mostrar_tiempos_parciales(self, parcial):
        ps = sorted(parcial, key=lambda x: (float(x[1]) if isinstance(x[1], (int,float)) else float('inf')))
        self.tree_times.delete(*self.tree_times.get_children())
        for n,t in ps:
            self.tree_times.insert("", "end", values=(n, f"{t:.4f}" if isinstance(t,(int,float)) else t))

    def _mostrar_tiempos_final(self):
        self.tree_times.delete(*self.tree_times.get_children())
        if not self.tiempos: return
        valores = []
        for _,v in self.tiempos:
            try:
                valores.append(float(v))
            except:
                valores.append(float('inf'))
        try:
            min_idx = valores.index(min(valores)); max_idx = valores.index(max(valores))
        except ValueError:
            min_idx = max_idx = -1
        for i,(n,t) in enumerate(self.tiempos):
            tag = 'normal'
            if i == min_idx: tag = 'fast'
            elif i == max_idx: tag = 'slow'
            display = f"{t:.4f}" if isinstance(t,(int,float)) else str(t)
            self.tree_times.insert("", "end", values=(n, display), tags=(tag,))
        self._actualizar_grafica()

    def graficar_o_generar(self):
        if not self.tiempos:
            if messagebox.askyesno("Ejecutar", "No hay tiempos medidos. ¿Deseas ejecutar los ordenamientos ahora?"):
                self.run_thread(); return
            else:
                self.generar_datos(); return
        self._show_graph_popup()

    def _actualizar_grafica(self):
        if not self.tiempos:
            self.ax.clear(); self.canvas.draw(); return
        nombres = [t[0] for t in self.tiempos]
        valores = []
        for _,v in self.tiempos:
            try:
                valores.append(float(v))
            except:
                valores.append(max([x for x in valores]) if valores else 1e9)
        self.ax.clear(); bars = self.ax.barh(nombres, valores); self.ax.invert_yaxis()
        self.ax.set_xlabel("Tiempo (ms)"); self.ax.set_title(f"Tiempos (10,000 elementos) - {self.tipo.get()}")
        try:
            min_idx = valores.index(min(valores)); max_idx = valores.index(max(valores))
            bars[min_idx].set_color("green"); bars[max_idx].set_color("red")
        except Exception:
            pass
        self.canvas.draw()

    def _show_graph_popup(self):
        popup = tk.Toplevel(self); popup.title("Gráfica ampliada - Tiempos"); popup.geometry("900x600")
        fig2, ax2 = plt.subplots(figsize=(9,6))
        nombres = [t[0] for t in self.tiempos]
        valores = []
        for _,v in self.tiempos:
            try:
                valores.append(float(v))
            except:
                valores.append(max(valores) if valores else 1e9)
        bars = ax2.barh(nombres, valores); ax2.invert_yaxis()
        ax2.set_xlabel("Tiempo (ms)")
        try:
            min_idx = valores.index(min(valores)); max_idx = valores.index(max(valores))
            bars[min_idx].set_color("green"); bars[max_idx].set_color("red")
        except:
            pass
        canvas2 = FigureCanvasTkAgg(fig2, master=popup); canvas2.get_tk_widget().pack(fill="both", expand=True); canvas2.draw()

    def _clear_tiempos_chart(self):
        self.tiempos = []; self.tree_times.delete(*self.tree_times.get_children()); self.ax.clear(); self.canvas.draw()
    def close(self): self.destroy()
