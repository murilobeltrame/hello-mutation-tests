import { ArgumentNullError } from '../errors/argument_null_error'

export class Author {
    
    public firstName!: string
    public lastName!: string

    constructor(init: Partial<Author>) {
        if (!init.firstName) throw new ArgumentNullError('firstName')
        if (!init.lastName) throw new ArgumentNullError('lastName')
        Object.assign(this, init)
    }
}