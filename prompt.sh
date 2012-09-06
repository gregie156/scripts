#!/bin/bash

prompt_cmd() {
	COLOR="\[\e[1;32m\]"
	TEXT_COLOR="\[\033[0;1m\]"
	dirname=$PWD;
	PS1="[${USER}@${HOSTNAME}:${dirname}]"

	fill=$COLUMNS-${#PS1}	

  	for ((i=0; i<$fill; i++)); do
    		PS1="${PS1}="
  	done
	PS1="${PS1}\r\n\$"
	PS1="${COLOR}${PS1}${TEXT_COLOR} "
	

}


export PROMPT_COMMAND=prompt_cmd
