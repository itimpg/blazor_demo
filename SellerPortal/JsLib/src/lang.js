export function getAppCulture() {
    return window.localStorage['AppLanguage'];
}

export function setAppCulture(value) {
    window.localStorage['AppLanguage'] = value;
}