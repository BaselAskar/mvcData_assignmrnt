"use strict";
//Select DOM
const langSelect = document.getElementById('lang-select');
const langs = document.getElementById('lang-list');
//Functions
function addPersonLanguage() {
    const langsInputList = langs.querySelectorAll('.itemInput');
    const langName = langSelect.value;
    const langsName = [];
    langsInputList.forEach(lang => langsName.push(lang.value));
    if (langsName.some(lang => lang === langName))
        return;
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
function removeLang(event) {
    const langItme = event.target.closest('.lang');
    langItme === null || langItme === void 0 ? void 0 : langItme.remove();
}
//# sourceMappingURL=add-person.js.map