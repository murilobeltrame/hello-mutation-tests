import { Author } from "../src/domain/entities/author";

describe('Author', () => {
    it(' should be instantiated', () => {
        var firstName = "Jhon";
        var lastName = "Doe";

        var author = new Author({firstName, lastName});

        expect(author.firstName).toEqual(firstName);
    });
});