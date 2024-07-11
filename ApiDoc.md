Rezepte:
https://api.chefkoch.de/v2/recipes?{parameter}
https://api.chefkoch.de/v2/recipes/{id}/{subseite}/{parameter}

Parameter:
offset - wie viele Seiten mit [limit] Einträgen übersprungen werden sollen
limit - wie viele Einträge angezeigt werden sollen
orderBy - nach was die Einträge geordnet werden sollen (2: datum)
order=0 - absteigend sortieren
(orderBy und order scheinen nur bei subseiten zu funktionieren)

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