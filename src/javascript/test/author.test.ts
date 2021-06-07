import { Author } from "../src/domain/entities/author";

describe('Author', () => {
    it(' should be instantiated', () => {
        const firstName = "Jhon";
        const lastName = "Doe";

        const author = new Author({firstName, lastName});

        expect(author.firstName).toEqual(firstName);
    });
});