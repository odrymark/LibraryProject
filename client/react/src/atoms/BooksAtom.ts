import { atom } from 'jotai';
import { type Book, handleGetBooks } from '../api';

export const booksAtom = atom<Book[]>([]);

export const fetchBooksAtom = atom(
    null,
    async (_get, set) => {
        try {
            const data = await handleGetBooks();
            set(booksAtom, data);
        } catch (error) {
            console.error("Failed to fetch books:", error);
        }
    }
);