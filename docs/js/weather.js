if ("geolocation" in navigator) {
  navigator.geolocation.getCurrentPosition(accept, denied);
} else {
  mislukt();
}

//Callback voor wanneer de gebruiker op accepteren heeft geklikt.
function accept(positie) {
  const lat = positie.coords.latitude;
  const lon = positie.coords.longitude;
  haalStadOp(lat, lon);
  haalWeerOp(lat, lon);
}

function denied() {
  console.log("Niet geaccepteerd");
}

async function haalStadOp(lat, lon) {
  const url = `https://api.bigdatacloud.net/data/reverse-geocode-client?latitude=${lat}&longitude=${lon}&localityLanguage=nl`;

  //Get request naar de bovenstaande url.
  const response = await fetch(url);

  const data = await response.json();

  //Pak in eerste instantie de stad naam, anders het lokale begied en tenslotte "Onbekende plaats" als niks is gevonden
  const stad = data.city || data.locality || "Niet bekend";

  const land = data.countryCode || "Niet bekend";

  console.log(`${stad}, ${land}`);
}

async function haalWeerOp(lat, lon) {
  const url = `https://api.open-meteo.com/v1/forecast?latitude=${lat}&longitude=${lon}&current=temperature_2m,weather_code,wind_speed_10m`;

  //Get request naar bovenstaande url
  const response = await fetch(url);

  const data = await response.json();

  const weer = data.current;

  const temperature = weer.temperature_2m || "Niet bekend";

  const weather_code = weer.weather_code || "Niet bekend";

  //todo: Tonen op de pagina als HTML
}

function haalWeerberichtOp(weather_code) {
  // 1. Return the new Promise instance
  return new Promise((resolve, reject) => {
    
    let bericht = '';
    
switch (weather_code) {

  case 0:
            omschrijving = "Helder";
            break;
        case 1:
            omschrijving = "Vrijwel onbewolkt";
            break;
        case 2:
            omschrijving = "Lichtbewolkt";
            break;
        case 3:
            omschrijving = "Bewolkt / Betrokken";
            break;
        case 45:
            omschrijving = "Mist";
            break;
        case 48:
            omschrijving = "Rijpnevel / Ruige vorst";
            break;
        case 51:
            omschrijving = "Lichte motregen";
            break;
        case 53:
            omschrijving = "Matige motregen";
            break;
        case 55:
            omschrijving = "Dichte motregen";
            break;
        case 56:
            omschrijving = "Lichte ijzelende motregen";
            break;
        case 57:
            omschrijving = "Dichte ijzelende motregen";
            break;
        case 61:
            omschrijving = "Lichte regen";
            break;
        case 63:
            omschrijving = "Matige regen";
            break;
        case 65:
            omschrijving = "Zware regen";
            break;
        case 66:
            omschrijving = "Lichte ijzel / vriezende regen";
            break;
        case 67:
            omschrijving = "Zware ijzel / vriezende regen";
            break;
        case 71:
            omschrijving = "Lichte sneeuwval";
            break;
        case 73:
            omschrijving = "Matige sneeuwval";
            break;
        case 75:
            omschrijving = "Zware sneeuwval";
            break;
        case 77:
            omschrijving = "Motsneeuw";
            break;
        case 80:
            omschrijving = "Lichte regenbuien";
            break;
        case 81:
            omschrijving = "Matige regenbuien";
            break;
        case 82:
            omschrijving = "Zeer zware regenbuien";
            break;
        case 85:
            omschrijving = "Lichte sneeuwbuien";
            break;
        case 86:
            omschrijving = "Zware sneeuwbuien";
            break;
        case 95:
            omschrijving = "Onweer";
            break;
        case 96:
            omschrijving = "Onweer met lichte hagel";
            break;
        case 99:
            omschrijving = "Onweer met zware hagel";
            break;

        default:
            omschrijving = "Onbekende weercode";
    }
  });
}
