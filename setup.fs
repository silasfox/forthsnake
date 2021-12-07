: newgame!
  0 head ! xdim 2 / ydim 2 / snake 2! 3 3 apple 2! 3 length !
  ['] up direction ! left step! left step! left step! left step! ;

: vi?      page ." Vi keys? (y/n)" key 121 = vi? ! ;
: greet    page ." Snake in Forth" ;
: delay    1000 ms ;
: run      200 gameloop ;
: prompts  vi?  greet ;
: setup    newgame! prompts delay ;

: go  setup run bye ;
