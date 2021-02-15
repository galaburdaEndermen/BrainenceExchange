import { getPictureByCode } from "./endpoints";

export default function getPictureUrlByCode(code) {
    return getPictureByCode + code;
}