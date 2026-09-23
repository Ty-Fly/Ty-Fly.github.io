if ("geolocation" in navigator) {
  navigator.geolocation.getCurrentPosition(gelukt, denied);
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
    console.log('Niet geaccepteerd')
}

async function haalStadOp(lat, lon) {

try {
    const url = `https://api.bigdatacloud.net/data/reverse-geocode-client?latitude=${lat}&longitude=${lon}&localityLanguage=nl`;
    
    //Get request naar de bovenstaande url.
    const response = await fetch(url);

    const data = response.json();
    
    //Pak in eerste instantie de stad naam, anders het lokaal uitzich en tenslotte "Onbekende plaats" als niks is gevonden
    const stad = data.city || data.locality || "Onbekende plaats";

    console.log(`stad data: \n${data}`)

} catch (fout) {
    console.log(`error: \n${fout}`)
}
}

async function haalWeerOp (lat, lon) {
    const url = `https://api.open-meteo.com/v1/forecast?latitude=${lat}&longitude=${lon}&current=temperature_2m,weather_code,wind_speed_10m`;
    
    //Get request naar bovenstaande url
    const response = await fetch(url)

    const data = await response.json();

    console.log(data)
}