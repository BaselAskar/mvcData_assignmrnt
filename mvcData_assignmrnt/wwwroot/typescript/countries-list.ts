//Select DOM
const countriesContainer = document.getElementById('countries')!;




//Functions
async function removeCountry(url: string): Promise<void> {

    const verify = confirm('Are you sure you would to remove the country and its cities...!');

    if (!verify) return;


    try {
        const response = await fetch(url, { method: 'DELETE' });

        if (!response.ok) throw "Field to delete the country.!";

        const htmlData = await response.text();

        countriesContainer.innerHTML = htmlData;
    }
    catch (err: any) {
        alert(err || err?.message);
    }
}