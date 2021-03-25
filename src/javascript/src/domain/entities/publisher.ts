export class Publisher {

    public name: string = '';

    constructor(init: Partial<Publisher>) {
        if (!init.name) throw new Error('Name cannot be null');
        Object.assign(this, init);
    }
}