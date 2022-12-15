
function changeRole(event: Event) {
    const form = (event.target as HTMLSelectElement).closest('form')!;

    form.submit();

}