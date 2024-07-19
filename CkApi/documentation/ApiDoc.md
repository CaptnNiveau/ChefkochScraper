Rezepte:
https://api.chefkoch.de/v2/recipes?{parameter}
https://api.chefkoch.de/v2/recipes/{id}/{subseite}/{parameter}

Parameter:
offset - wie viele Seiten mit [limit] Einträgen übersprungen werden sollen (maximum: 1000)
limit - wie viele Einträge angezeigt werden sollen
orderBy - nach was die Einträge geordnet werden sollen
    bekannte funktionierende Werte: 1, 3, 6, 7, 8
        3: Bewertung
        6: Neuheiten
minimumRating - trivial (2,3,4,5)
maximumTime - trivial (15,30,60,120)
tags - trivial (siehe tags.md)
order=0 - nach Datum aufsteigend sortieren (nur bei subseiten)

Subseiten:
comments
images


User:
https://api.chefkoch.de/v2/users/{id}/profile
ID ist eine GUID (ohne Bindestriche)
/profile ist optional, gibt zusätzliche infos


Funktionierende Beispiele:
https://api.chefkoch.de/v2/recipes?offset=1&limit=100
https://api.chefkoch.de/v2/recipes/820481186558221/comments?offset=0&limit=1534&order=0&orderBy=2
https://api.chefkoch.de/v2/recipes/820481186558221/images
https://api.chefkoch.de/v2/users/bcfce3497b42e48f1210823471c1312f
https://api.chefkoch.de/v2/users/20e708ecd33873e645be0c26b984f239/profile