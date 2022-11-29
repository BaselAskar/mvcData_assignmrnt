//Select DOM
const langSelect = document.getElementById('lang-select')! as HTMLSelectElement;
const langs = document.getElementById('lang-list')!;





//Functions
function addPersonLanguage() {

    const langsInputList = langs.querySelectorAll('.itemInput') as NodeListOf<HTMLInputElement>;
    const langName = langSelect.value;

    const langsName: string[] = [];

    langsInputList.forEach(lang => langsName.push(lang.value));

    if (langsName.some(lang => lang === langName)) return;


    const html = `
        <div class="lang col-12 col-md-6 col-lg-4">
            <div class="item-content">
                <input class='itemInput' type='text' readonly name='LangsName[]' value='${langName}' />
                <button onclick='removeLang(event)' type='button' class='close btn btn-close'/>
            </div>
        </div>
    `;

    langs.insertAdjacentHTML('beforeend', html);
}



function removeLang(event: Event) {
    const langItme = (event.target as HTMLElement).closest('.lang');

    langItme?.remove();
}
