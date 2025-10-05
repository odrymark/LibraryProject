import { atom } from 'jotai';
import {type Genre, handleGetGenres} from '../api';

export const genresAtom = atom<Genre[]>([]);

export const fetchGenresAtom = atom(
    null,
    async (_get, set) => {
        try {
            const data = await handleGetGenres();
            set(genresAtom, data);
        } catch (error) {
            console.error("Failed to fetch genres:", error);
        }
    }
);