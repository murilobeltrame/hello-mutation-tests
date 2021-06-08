export class ArgumentError extends Error {
    constructor(paramName?: string) {
        super(`Param has an invalid value. ${paramName ? paramName : ''}`)
    }
}