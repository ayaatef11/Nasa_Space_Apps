//fetch data 
let planetData = {};

// Fetch the JSON data when the page loads
debugger
fetch('./majorbodies.json')
    .then(response => response.json())
    .then(data => {
        planetData = data; // Store the data globally
    })
    .catch(error => console.error('Error fetching planet data:', error));

    /*const planetsObject = planetData.reduce((acc, planet) => {
        acc[planet.name] = planet; // Use the planet's name as the key
        return acc;
      }, {});
*/
    function selectPlanet(planet) {
        debugger
        // Retrieve the selected planet's data from the JSON
        const selectedPlanet = planetData[planet];
    
        // Clear any existing details (if needed)
        const detailsContainer = document.getElementById("planetDetails");
        detailsContainer.innerHTML = ''; // Clear previous details
    
        // Create elements to display the attributes fetched by selected planets
        const nameDiv = document.createElement("div");
        nameDiv.textContent = `Name: ${selectedPlanet.name}`;
        
        const typeDiv = document.createElement("div");
        typeDiv.textContent = `Type: ${selectedPlanet.type}`;
        
        const textureDiv = document.createElement("div");
        textureDiv.textContent = `Texture: ${selectedPlanet.texture}`;
        
        const customOrbitDiv = document.createElement("div");
        customOrbitDiv.textContent = `Custom Orbit: ${selectedPlanet.customOrbit}`;
    
        // Append the created elements to the details container
        detailsContainer.appendChild(nameDiv);
        detailsContainer.appendChild(typeDiv);
        detailsContainer.appendChild(textureDiv);
        detailsContainer.appendChild(customOrbitDiv);
    }