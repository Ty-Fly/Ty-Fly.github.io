if ("geolocation" in navigator) {
  navigator.geolocation.getCurrentPosition(accept, denied);
} else {
  denied();
}

//Callback voor wanneer de gebruiker op accepteren heeft geklikt.
function accept(positie) {
  const lat = positie.coords.latitude;
  const lon = positie.coords.longitude;
  haalStadOp(lat, lon);
  haalWeerOp(lat, lon);
}

function denied() {

  document.getElementById("weer-locatie").textContent = "Locatie niet gedeeld";
  document.getElementById("weer-temperatuur").textContent = "--°C";
  document.getElementById("weer-omschrijving").textContent = "Sta locatietoegang toe om het weer te zien.";
  
}

async function haalStadOp(lat, lon) {
  const url = `https://api.bigdatacloud.net/data/reverse-geocode-client?latitude=${lat}&longitude=${lon}&localityLanguage=nl`;
  const locatieEl = document.getElementById("weer-locatie");

  try {
    const response = await fetch(url);
    const data = await response.json();

    // data bestaat alleen binnen dit try-blok, dus hier gebruiken
    const stad = data.city || data.locality || "Onbekende plaats";
    const land = data.countryCode ?? "";

    locatieEl.textContent = `${stad}${land ? ", " + land : ""}`;
  } catch (error) {
    console.log("Stad ophalen mislukt:", error);
    locatieEl.textContent = "Locatie niet gevonden";
  }
}


async function haalWeerOp(lat, lon) {
  const url = `https://api.open-meteo.com/v1/forecast?latitude=${lat}&longitude=${lon}&current=temperature_2m,weather_code,wind_speed_10m`;

  try {
    const response = await fetch(url);
    const data = await response.json();
    const weer = data.current;

    const temperatuur = weer.temperature_2m;
    const windsnelheid = weer.wind_speed_10m;

    document.getElementById("weer-temperatuur").textContent = `${Math.round(temperatuur)}°C`;
    document.getElementById("weer-omschrijving").textContent = haalWeerberichtOp(weer.weather_code);
    document.getElementById("weer-wind").textContent = `Wind: ${windsnelheid} km/u`;
    
  } catch (error) {
    console.log("Weer ophalen mislukt:", error);
    document.getElementById("weer-omschrijving").textContent =
      "Weer kon niet worden opgehaald";
  }
}

function haalWeerberichtOp(weather_code) {
  const weerCodes = {
  0: "Helder",
  1: "Vrijwel onbewolkt",
  2: "Lichtbewolkt",
  3: "Bewolkt / Betrokken",
  45: "Mist",
  48: "Rijpnevel / Ruige vorst",
  51: "Lichte motregen",
  53: "Matige motregen",
  55: "Dichte motregen",
  56: "Lichte ijzelende motregen",
  57: "Dichte ijzelende motregen",
  61: "Lichte regen",
  63: "Matige regen",
  65: "Zware regen",
  66: "Lichte ijzel / vriezende regen",
  67: "Zware ijzel / vriezende regen",
  71: "Lichte sneeuwval",
  73: "Matige sneeuwval",
  75: "Zware sneeuwval",
  77: "Motsneeuw",
  80: "Lichte regenbuien",
  81: "Matige regenbuien",
  82: "Zeer zware regenbuien",
  85: "Lichte sneeuwbuien",
  86: "Zware sneeuwbuien",
  95: "Onweer",
  96: "Onweer met lichte hagel",
  99: "Onweer met zware hagel",
};

return weerCodes[weather_code] ?? "Onbekende weercode";
}
