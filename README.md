# Fibonacci

## Le contexte

Voulant jouer avec le mot clé Yield en C#, je me suis lancé, de manière candide, dans le calcul de la suite de Fibonacci. J'ai dévouvert un univers bien plus complexe qu'il n'y parait.

## La suite en elle même
Le principe de calcul en lui même est simple. Le terme N est la somme des deux termes précédents : `Fn = Fn-2 + Fn-1`

Exemple au rang 11 :
```
Rang 9 = 34
Rang 10 = 55
Rang 11 = 34 + 55 => 89 
```

cf : https://en.wikipedia.org/wiki/Fibonacci_sequence

## Les problèmes rencontrés
### Limitation de la taille des entiers
Avec la suite de Fibonacci, on rencontre rapidement un problème d'espace mémoire de stockage des entiers. En effet à partir du 187éme terme, la valeur est composée de 39 chiffres.

### Le temps de réponse
Avec la méthode candide que j'ai utilisée, pour calculer le 50 000éme terme, le temps de calcul est de l'ordre de 16s environ, ce qui dans un contexte d'appel HTTP ne serait pas concevable.
Pour améliorer cela, je suis passé au calcul matricel à base d'exponentiation matricielle binaire. 

A ce jour les resultats ne sont pas ceux escomptés, tous les bénéfices du calcul matriciel sont perdus dans les multiplications et les additions des UStringNumbers.


## Webographie
- [yield statement - provide the next element](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/yield)
- [Exponentiation matricielle | Exponentiation rapide](https://youtu.be/Hh3bfcbUdzo?si=_mWnPP-5tVUr7-fZ)
- [C# 11.0: Generic Math, C# Operators and Static Abstract/Virtual Interface Members](https://www.thomasclaudiushuber.com/2023/01/24/csharp-11-generic-math/)

## Auteur
[![build](https://img.shields.io/badge/LinkedIn-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/cyril-cophignon-b58b5a5b/)