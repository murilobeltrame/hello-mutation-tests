export class ArgumentNullError extends Error {
    constructor(paramName?: string) {
        super(`Param can't be null. ${paramName ? paramName : ''}`);
    }
}