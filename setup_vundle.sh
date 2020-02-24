#!/usr/bin/env bash

echo "#######################################"
echo "run this script with: 'bash <(curl -L https://tiny.cc/vundle)' as the user who uses Vim"
echo "If you don't have anything important in your Vim environemnt, you might want to wipe it."
echo "You can wipe it by doing 'rm -rf ~/.vim*'"

echo "The script installs Vundle, a vim plugin manager. Plus some basic plugins."
echo "It adds <ctrl-P> for fuzze file navigation, and <shift-P> for ctag-navigation."
echo "<F9> for tagbar, <S-~> for file navigation"
echo "Fixes some vim mouse issues and some other minor things."

echo "see https://github.com/VundleVim/Vundle.vim for more info"
echo "find more plugins at https://vimawesome.com/"
echo "#######################################"

ls ~/.vim/bundle/Vundle.vim ||
git clone https://github.com/VundleVim/Vundle.vim.git ~/.vim/bundle/Vundle.vim &&

touch ~/.vimrc &&

{ cat > /tmp/.vimrc <<-HEREDOC
set nocompatible              " Set Vim and not VI mode. required.
filetype off                  " required

set rtp+=~/.vim/bundle/Vundle.vim  " needed for vundle to work
call vundle#begin()
    Plugin 'VundleVim/Vundle.vim'  " vundle plugin manager
    Plugin 'kien/ctrlp.vim'        " ctrlP for fuzzy file search and fuzzy tag search
    Plugin 'majutsushi/tagbar'     " outline of file structure with classes and methods
    Plugin 'scrooloose/nerdtree'   " better file browser
    Plugin 'davidhalter/jedi-vim'    " intellisense/autocompletion 
    Plugin 'andviro/ropevim-bundled' " for refactoring
    Plugin 'scrooloose/syntastic'  " static type checking
    Plugin 'ludovicchabant/vim-gutentags'  " automatic ctags management
    Plugin 'tpope/vim-fugitive' " git integration
    Plugin 'vim-airline/vim-airline'  " better status line
    Plugin 'vim-airline/vim-airline-themes'" status line themes 

    
call vundle#end()  "required
filetype plugin indent on  " required
                                                                                                                                     
HEREDOC
} &&
cat ~/.vimrc >> /tmp/.vimrc &&
cp /tmp/.vimrc ~/.vimrc &&

vim +PluginInstall +qall && 

{ cat >> ~/.vimrc <<HEREDOC
set mouse=a
set ttymouse=xterm2 " another good setting could be ttymouse=sgr
set wildmenu  " show possible menu items as you type. Ueseful with :e and :split
set showcmd " show currently entered command

" better search behaviour
set ignorecase
set smartcase
set incsearch

" tabs are important for python
set expandtab  " turn tabs to spaces
set tabstop=4  " tabs to be 4 wide
set shiftwidth=4  " when doing shift

set visualbell " no loud noises on error

map <S-P> :CtrlPTag<CR>
nnoremap <silent> <F9> :TagbarOpen fj<CR>
map <F8> :NERDTreeToggle<CR>

" make vim tab-completions behave like Linux
set wildmode=longest,list,full


" syntastic basic settings
set statusline+=%#warningmsg#
set statusline+=%{SyntasticStatuslineFlag()}
set statusline+=%*

let g:syntastic_always_populate_loc_list = 1
let g:syntastic_auto_loc_list = 1
let g:syntastic_check_on_open = 1
let g:syntastic_check_on_wq = 0
let g:syntastic_python_mypy_args = "--py2"
let g:syntastic_python_checkers = ["mypy" ]

" airline plugin configuration
let g:airline_inactive_collapse=0

HEREDOC
}



