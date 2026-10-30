# Calculadora Modular en C# (Laboratorio 4.6)

Aplicación de consola desarrollada con principios de arquitectura modular y separación de responsabilidades.

## Características de la Arquitectura
- **Modularidad e Independencia (RF-14):** Métodos de cálculo puros (Sumar, Restar, Multiplicar, Dividir) completamente desacoplados de la consola.
- **Tipado Eficiente:** Uso del tipo Byte para las opciones del menú con el fin de optimizar el consumo de memoria.
- **Programación Defensiva (RF-08, RF-09):** Validación con decimal.TryParse con reintento ante entradas no numéricas y blindaje contra división entre cero.
- **Casos de prueba:** Cobertura de los casos CP-01 al CP-11 del documento BRD.
