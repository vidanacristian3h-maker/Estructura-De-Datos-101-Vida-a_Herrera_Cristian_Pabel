# main.py
import tkinter as tk
from tkinter import messagebox
from form_cien import FrmCien
from form_mil import FrmMil
from form_diezmil import FrmDiezMil
from form_cienmil import FrmCienMil

class FrmPrincipal(tk.Tk):
    def __init__(self):
        super().__init__()
        self.title("Comparador de Algoritmos - Menú")
        self.geometry("780x450")
        self.configure(bg="white")
        self._create_widgets()

    def _create_widgets(self):
        titulo = tk.Label(self, text="🔹 Comparador de Algoritmos de Ordenamiento 🔹",
                          font=("Segoe UI", 16, "bold"), bg="white")
        titulo.pack(pady=18)

        subt = tk.Label(self, text="Selecciona el tamaño de datos", font=("Segoe UI", 11), bg="white")
        subt.pack(pady=6)

        btn_frame = tk.Frame(self, bg="white")
        btn_frame.pack(pady=12)

        tk.Button(btn_frame, text="100 Datos", width=20, height=2, command=lambda: FrmCien(self)).grid(row=0, column=0, padx=8, pady=8)
        tk.Button(btn_frame, text="1,000 Datos", width=20, height=2, command=lambda: FrmMil(self)).grid(row=0, column=1, padx=8, pady=8)
        tk.Button(btn_frame, text="10,000 Datos", width=20, height=2, command=lambda: FrmDiezMil(self)).grid(row=1, column=0, padx=8, pady=8)
        tk.Button(btn_frame, text="100,000 Datos", width=20, height=2, command=lambda: FrmCienMil(self)).grid(row=1, column=1, padx=8, pady=8)

        tk.Button(self, text="Salir", width=14, height=2, bg="#e04b4b", fg="white", command=self._salir).pack(pady=16)

    def _salir(self):
        if messagebox.askyesno("Salir", "¿Deseas salir?"):
            self.destroy()

if __name__ == "__main__":
    app = FrmPrincipal()
    app.mainloop()
