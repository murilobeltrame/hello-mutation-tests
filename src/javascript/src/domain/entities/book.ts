import { Author } from "./author";
import { Publisher } from "./publisher";

export class Book {
    
    public authors: Author[] = [];
    public publisher: Publisher = new Publisher({name:''});
    public title: string = '';
    public pages?: number = undefined;

    constructor(init: Partial<Book>) {
        if (!init.title) throw new Error('Title cannot be null');
        if (!init.publisher) throw new Error('Publisher cannot be null');
        if (init.authors?.length ?? 0) throw new Error('Authors cannot be empty');
        Object.assign(this, init);
    }
}