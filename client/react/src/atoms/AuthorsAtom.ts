import { atom } from 'jotai';
import { type Author, handleGetAuthors } from '../api';

export const authorsAtom = atom<Author[]>([]);

export const fetchAuthorsAtom = atom(
    null,
    async (_get, set) => {
        try {
            const data = await handleGetAuthors();
            set(authorsAtom, data);
        } catch (error) {
            console.error("Failed to fetch authors:", error);
        }
    }
);