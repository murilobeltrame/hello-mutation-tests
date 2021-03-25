export class Author {
    
    public firstName: string = '';
    public lastName: string = '';

    constructor(init: Partial<Author>) {
        if (!init.firstName) throw new Error('firstName cannot be null');
        if (!init.lastName) throw new Error('lastName cannot be null');
        Object.assign(this, init);
    }
}