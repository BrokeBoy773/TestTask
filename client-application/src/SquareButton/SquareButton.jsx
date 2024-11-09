import React from 'react';
import Classes from './SquareButton.module.css';

export const SquareButton = ({children, ...props}) => {
  return (
    <button className={Classes.squareButton} {...props}>
        {children}
    </button>
  );
}
