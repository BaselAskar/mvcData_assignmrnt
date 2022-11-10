const deleteBtns = document.querySelectorAll('.remove');

const peopleList = document.querySelector('.list');








function removePeopleHandler(event) {
    const button = event.target.closest('.remove');
    const row = event.target.closest('.row');

    const url = button.dataset.url;

    $.ajax({
        url: url,
        type: 'DELETE',
        success: (result) => {
            peopleList.innerHTML = result;
        }

    });

}