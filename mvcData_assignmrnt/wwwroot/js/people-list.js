const deleteBtns = document.querySelectorAll('.remove');

const peopleList = document.querySelector('.list');








function removePeopleHandler(url,name) {

    $.ajax({
        url: url,
        type: 'DELETE',
        success: (result) => {
            peopleList.innerHTML = result;
            alert(`${name} has been removed...!`);
        }

    });

}


function findById(url) {
    const personId = $('#search-id').val();
    $.get(url + '/' + personId, result => peopleList.innerHTML = result);
}


function getAllPeople(url) {
    $.get(url, result => peopleList.innerHTML = result)
}


function getBy(url) {
    const searchText = $('#search-input').val().trim();
    const searchBy = $('#search-by-select').val();
    $.get(url + `?search=${searchText}&by=${searchBy}`, result => peopleList.innerHTML = result);
}