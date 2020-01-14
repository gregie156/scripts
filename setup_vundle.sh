#!/usr/bin/env bash

echo "#######################################"
echo "run this script with: 'bash <(curl -L https://tiny.cc/vundle)' as the user who uses Vim"

echo "it installs Vundle, a vim plugin manager, plus some basic plugins."
echo "it adds <ctrl-P> for fuzze file navigation, and <shift-P> for ctag-navigation."
echo "And <F9> for tagbar
echo "Fixes some vim mouse issues and some other minor things."

echo "see https://github.com/VundleVim/Vundle.vim for more info"
echo "find more plugins at https://vimawesome.com/"
echo "#######################################"

git clone https://github.com/VundleVim/Vundle.vim.git ~/.vim/bundle/Vundle.vim &&

touch ~/.vimrc &&

{ cat > /tmp/.vimrc <<-HEREDOC
  set nocompatible              " be iMproved, required
  filetype off                  " required

  " set the runtime path to include Vundle and initialize
  set rtp+=~/.vim/bundle/Vundle.vim
  call vundle#begin()
  " alternatively, pass a path where Vundle should install plugins
  "call vundle#begin('~/some/path/here')

  " let Vundle manage Vundle, required
  Plugin 'VundleVim/Vundle.vim'

  " The following are examples of different formats supported.
  " Keep Plugin commands between vundle#begin/end.
  
  " plugin on GitHub repo
  " https://github.com/tpope/vim-fugitive
  " Plugin 'tpope/vim-fugitive'
  " plugin from http://vim-scripts.org/vim/scripts.html
  " Plugin 'L9'
  
  " Git plugin not hosted on GitHub
  " https://github.com/wincent/command-t
  " Plugin 'git://git.wincent.com/command-t.git'
  
  " git repos on your local machine (i.e. when working on your own plugin)
  " Plugin 'file:///home/gmarik/path/to/plugin'
  
  " The sparkup vim script is in a subdirectory of this repo called vim.
  " Pass the path to set the runtimepath properly.
  " Plugin 'rstacruz/sparkup', {'rtp': 'vim/'}
  " Install L9 and avoid a Naming conflict if you've already installed a
  " different version somewhere else.
  " Plugin 'ascenator/L9', {'name': 'newL9'}
  
  " adds ctrl-p and if you have ctags, also shfit-p
  Plugin 'kien/ctrlp.vim'
  
  " tagbar bound to F9
  " https://github.com/majutsushi/tagbar
  Plugin 'majutsushi/tagbar'


  " All of your Plugins must be added before the following line
  call vundle#end()            " required
  filetype plugin indent on    " required
  " To ignore plugin indent changes, instead use:
  "filetype plugin on
  "
  " Brief help
  " :PluginList       - lists configured plugins
  " :PluginInstall    - installs plugins; append `!` to update or just :PluginUpdate
  " :PluginSearch foo - searches for foo; append `!` to refresh local cache
  " :PluginClean      - confirms removal of unused plugins; append `!` to auto-approve removal
  "
  " see :h vundle for more details or wiki for FAQ
  " Put your non-Plugin stuff after this line
HEREDOC
} &&
cat ~/.vimrc >> /tmp/.vimrc &&
cp /tmp/.vimrc ~/.vimrc &&

vim +PluginInstall +qall && 

{ cat >> ~/.vimrc <<HEREDOC
set mouse=a 
set ttymouse=xterm2 " another good setting could be ttymouse=sgr
set wildmenu

set ignorecase
set smartcase
set incsearch

set expandtab  " turn tabs to spaces
set tabstop=4  " tabs to be 4 wide
set shiftwidth=4  " when doing shift 

map <S-P> :CtrlPTag<CR>
nnoremap <silent> <F9> :TagbarOpen fj<CR>

HEREDOC
}



