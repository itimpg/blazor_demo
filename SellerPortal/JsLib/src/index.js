import { getAppCulture, setAppCulture } from './lang';

export function GetAppCulture() {
    return getAppCulture();
}

export function SetAppCulture(value) {
    return setAppCulture(value);
}