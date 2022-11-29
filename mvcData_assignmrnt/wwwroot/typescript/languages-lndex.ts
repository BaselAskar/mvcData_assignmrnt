//Select DOM
const langList = document.getElementById('languages-list')!;
const validText = document.getElementById('valid-name')!;
const langNameInp = document.getElementById('Name')! as HTMLInputElement;






//Functions
async function addLanguage(event: SubmitEvent, url: string): Promise<void> {
    event.preventDefault();
    validText.innerHTML = '';
    langNameInp.classList.remove('is-invalid')
    const languageName = langNameInp.value.trim();
    const response = await fetch(`${url}?name=${languageName}`, { method: 'POST' });

    if (!response.ok) {
        const errorResult = await response.text();
        langNameInp.classList.add('is-invalid');
        validText.innerHTML = errorResult;
        return;
    }

    const data = await response.text();
    langNameInp.value = '';

    langList.innerHTML = data;
}



async function removeLanguage(url: string): Promise<void> {
    const response = await fetch(url, { method: 'DELETE' });

    if (!response.ok) alert(await response.text());

    const data = await response.text();

    langList.innerHTML = data;
}



