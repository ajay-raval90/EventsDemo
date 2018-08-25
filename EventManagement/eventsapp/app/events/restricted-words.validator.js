"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
function restrictedWords(words) {
    return function (control) {
        if (!words) {
            return null;
        }
        var inValidWords = words
            .map(function (w) { return control.value.includes(w) ? w : null; })
            .filter(function (w) { return w != null; });
        return inValidWords && inValidWords.length > 0 ?
            { 'restrictedWords': inValidWords.join(" ,") } : null;
    };
}
exports.restrictedWords = restrictedWords;
//# sourceMappingURL=restricted-words.validator.js.map