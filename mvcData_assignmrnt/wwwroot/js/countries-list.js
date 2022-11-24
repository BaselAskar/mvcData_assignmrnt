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
const countriesContainer = document.getElementById('countries');
//Functions
function removeCountry(url) {
    return __awaiter(this, void 0, void 0, function* () {
        const verify = confirm('Are you sure you would to remove the country and its cities...!');
        if (!verify)
            return;
        try {
            const response = yield fetch(url, { method: 'DELETE' });
            if (!response.ok)
                throw "Field to delete the country.!";
            const htmlData = yield response.text();
            countriesContainer.innerHTML = htmlData;
        }
        catch (err) {
            alert(err || (err === null || err === void 0 ? void 0 : err.message));
        }
    });
}
//# sourceMappingURL=countries-list.js.map