: reset-head       0 head ! ;
: reset-length     3 length ! ;
: reset-pos        center snake 2! ;
: reset-snake      reset-head reset-pos reset-length ;
: reset-apple      3 xdim myrand 3 ydim myrand apple 2! ;
: reset-direction  ['] up direction ! ;

: newgame!  reset-snake reset-apple reset-direction ;

: vi?      draw-frame s" Vi keys? (y/n)" .at-center key 121 = vi? ! ;
: greet    draw-frame s" Snake in Forth" .at-center ;
: delay    1000 ms ;
: run      200 gameloop ;
: prompts  greet delay vi? ;
: setup    page newgame! prompts ;

: go  setup run bye ;
