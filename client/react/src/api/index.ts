import { Api } from './Api';

export type Book = {
    id: number;
    title: string;
    pages: number;
    author: string[];
    genre: string;
};

export type Genre = {
    id: number;
    name: string;
    numOfBooks: number;
};

export type Author = {
    id: number;
    name: string;
    numOfBooks: number;
};

export const defApi = new Api({
    baseUrl: "http://localhost:5028"
});

export async function handleGetBooks(): Promise<Book[]> {
    try {
        const res = await defApi.library.libraryGetAllBooks();
        return await res.json();
    } catch (error) {
        console.error("Failed to fetch books:", error);
        return [];
    }
}

export async function handleGetGenres(): Promise<Genre[]> {
    try {
        const res = await defApi.library.libraryGetGenres();
        return await res.json();
    } catch (error) {
        console.error("Failed to fetch genres:", error);
        return [];
    }
}

export async function handleGetAuthors(): Promise<Author[]> {
    try {
        const res = await defApi.library.libraryGetAuthors();
        return await res.json();
    } catch (error) {
        console.error("Failed to fetch authors:", error);
        return [];
    }
}

export async function handleAddBook(bookData: Book) {
    try {
        await defApi.library.libraryAddBook(bookData);
        alert("Book added successfully.");
    } catch (error) {
        console.error("Failed to add book:", error);
        alert("Failed to add book.");
    }
}