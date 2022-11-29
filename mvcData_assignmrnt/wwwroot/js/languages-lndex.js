"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
//Select DOM
const langList = document.getElementById('languages-list');
const validText = document.getElementById('valid-name');
const langNameInp = document.getElementById('Name');
//Functions
function addLanguage(event, url) {
    return __awaiter(this, void 0, void 0, function* () {
        event.preventDefault();
        validText.innerHTML = '';
        langNameInp.classList.remove('is-invalid');
        const languageName = langNameInp.value.trim();
        const response = yield fetch(`${url}?name=${languageName}`, { method: 'POST' });
        if (!response.ok) {
            const errorResult = yield response.text();
            langNameInp.classList.add('is-invalid');
            validText.innerHTML = errorResult;
            return;
        }
        const data = yield response.text();
        langNameInp.value = '';
        langList.innerHTML = data;
    });
}
function removeLanguage(url) {
    return __awaiter(this, void 0, void 0, function* () {
        const response = yield fetch(url, { method: 'DELETE' });
        if (!response.ok)
            alert(yield response.text());
        const data = yield response.text();
        langList.innerHTML = data;
    });
}
//# sourceMappingURL=languages-lndex.js.map