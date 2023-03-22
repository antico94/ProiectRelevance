using ProiectRelevance;
using ProiectRelevance.Items;
using ProiectRelevance.Menu;

int numarMaxim = Utils.GetValidIntegerFromUser("Introduceti numarul maxim de iteme: ");
float greutateMaxima = Utils.GetValidFloatFromUser("Introduceti greutatea maxima: ");
float volumMaxim = Utils.GetValidFloatFromUser("Introduceti volumul maxim: ");


var ghiozdan = new Ghiozdan(numarMaxim, greutateMaxima, volumMaxim);
var meniu = new Meniu(ghiozdan);

meniu.Interactioneaza();


