import React, { useState } from 'react';
import Classes from './BookBox.module.css';
import { BookList } from '../BookList/BookList';
import { SquareButton } from '../SquareButton/SquareButton';
import { BookService } from '../BookService/BookService';

export const BookBox = ({ bookList, fetchBookList }) => {
    const [searchString, setSearchString] = useState('');
    const [title, setTitle] = useState('');

    const handleSearchBook = async () => {
        fetchBookList(searchString)
        setSearchString('');
    };

    const handleAddBook = async () => {
        await BookService.createBookAsync({ title });
        fetchBookList(null);
        setTitle('');
    };

    return (
        <div className={Classes.container}>
            <div className={Classes.input}>
                <input
                    value={searchString}
                    onChange={x => setSearchString(x.target.value)}
                    type='text'
                    placeholder='Найти книгу'
                />

                <SquareButton onClick={handleSearchBook}>
                    Искать
                </SquareButton>
            </div>

            <div className={Classes.input}>
                <input
                    value={title}
                    onChange={x => setTitle(x.target.value)}
                    type='text'
                    placeholder='Добавить книгу'
                />

                <SquareButton onClick={handleAddBook}>
                    Добавить
                </SquareButton>
            </div>

            <BookList bookList={bookList} fetchBookList={fetchBookList} />
        </div>
    )
}
