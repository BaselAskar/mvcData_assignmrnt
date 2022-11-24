"use strict";
//Select Dom
const cityInp = document.getElementById('city-input');
const addCityBtn = document.getElementById('add-city-btn');
const citiesContainer = document.getElementById('cities');
//const citiesForm = document.getElementById('city-form') as HTMLFormElement;
const nameInput = document.querySelector('#Name');
const tokenInput = document.querySelector('input[name="__RequestVerificationToken"]');
//Functions
function addCity(event) {
    event.preventDefault();
    const cityName = cityInp.value.trim();
    const citiesNamesEl = document.querySelectorAll('.cityName');
    const citiesName = [];
    citiesNamesEl.forEach(el => citiesName.push(el.value));
    if (cityName === '')
        return;
    if (citiesName.some(name => name.toLowerCase() === cityName.toLowerCase())) {
        cityInp.value = '';
        return;
    }
    const html = `
        <div class="city col-12 col-md-6 col-lg-4">
            <div class="city-content">
                <input class='cityName' type='text' readonly name='Cities[]' value='${cityName}' form='form' />
                <button onclick='removeCity(event)' type='button' class='close btn btn-close'/>
            </div>
        </div>
    `;
    citiesContainer.insertAdjacentHTML('beforeend', html);
    cityInp.value = '';
}
function removeCity(event) {
    const cityEl = event.target.closest('.city');
    cityEl.remove();
}
//# sourceMappingURL=add-country.js.map