import { FormControl } from "@angular/forms";
export function restrictedWords(words: string[]) {
    return (control: FormControl): { [key: string]: any } => {
        if (!words) {
            return null;
        }
        var inValidWords = words
            .map(w => control.value.includes(w) ? w : null)
            .filter(w => w != null);


        return inValidWords && inValidWords.length > 0 ?
            { 'restrictedWords': inValidWords.join(" ,") } : null;
    }
}