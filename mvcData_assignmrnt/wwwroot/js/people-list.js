const deleteBtns = document.querySelectorAll('.remove');

deleteBtns.forEach(btn => btn.addEventListener('click', removePeopleHandler))







function removePeopleHandler(event) {
    const button = event.target.closest('.remove');
    const row = event.target.closest('.row');

    const url = button.dataset.url;

    $.ajax({
        url: url,
        type: 'DELETE',
        success: (_) => {
            window.location.reload();
        }

    });

}