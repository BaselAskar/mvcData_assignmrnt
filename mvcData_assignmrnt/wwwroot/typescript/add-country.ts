//Select Dom
const cityInp = document.getElementById('city-input')! as HTMLInputElement;
const addCityBtn = document.getElementById('add-city-btn') as HTMLButtonElement;
const citiesContainer = document.getElementById('cities') as HTMLDivElement;
//const citiesForm = document.getElementById('city-form') as HTMLFormElement;
const nameInput = document.querySelector('#Name')! as HTMLInputElement;
const tokenInput = document.querySelector('input[name="__RequestVerificationToken"]')! as HTMLInputElement;







//Functions
function addCity(event: SubmitEvent) {
    event.preventDefault();
    const cityName = cityInp.value.trim();
    const citiesNamesEl = document.querySelectorAll('.cityName') as NodeListOf<HTMLInputElement>
    const citiesName:string[] = [];

    citiesNamesEl.forEach(el => citiesName.push(el.value));


    if (cityName === '') return;

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


function removeCity(event: Event) {
    const cityEl = (event.target as HTMLElement).closest('.city')!;

    cityEl.remove();
}



