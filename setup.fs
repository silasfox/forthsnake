: reset-head       0 head ! ;
: reset-length     3 length ! ;
: reset-pos        xdim 2 / ydim 2 / snake 2! ;
: reset-snake      reset-head reset-pos reset-length ;
: reset-apple      3 xdim myrand 3 ydim myrand apple 2! ;
: reset-direction  ['] up direction ! ;

: newgame!  reset-snake reset-apple reset-direction ;

: vi?      page ." Vi keys? (y/n)" key 121 = vi? ! ;
: greet    page ." Snake in Forth" ;
: delay    1000 ms ;
: run      200 gameloop ;
: prompts  vi?  greet ;
: setup    newgame! prompts delay ;

: go  setup run bye ;
