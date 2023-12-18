import os

def ersetze_mtllib(dateiname):
    # Extrahiere den Dateinamen ohne Erweiterung
    dateiname_ohne_erweiterung = os.path.splitext(os.path.basename(dateiname))[0]

    # Datei lesen
    with open(dateiname, 'r') as datei:
        zeilen = datei.readlines()

    # Durchsuche die Zeilen nach der Zeichenkette "mtllib get-color.mtl" und ersetze sie
    for i, zeile in enumerate(zeilen):
        if  f"mtllib {dateiname_ohne_erweiterung}.mtl" in zeile:
            zeilen[i] = zeile.replace(f"mtllib {dateiname_ohne_erweiterung}.mtl","mtllib get-color.mtl")

    # Aktualisierte Zeilen in die Datei schreiben
    with open(dateiname, 'w') as datei:
        
        datei.writelines(zeilen)

# Durchsuche alle .obj-Dateien im gleichen Verzeichnis wie das Skript
verzeichnis = os.path.dirname(os.path.realpath(__file__))
for dateiname in os.listdir(verzeichnis):
    if dateiname.endswith(".obj"):
        dateipfad = os.path.join(verzeichnis, dateiname)
        ersetze_mtllib(dateipfad)
