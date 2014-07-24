function getFileName() {
    return $('input[type=file]').val().replace(/.*(\/|\\)/, '');
}
