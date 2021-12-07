: newgame!
  0 head ! xdim 2 / ydim 2 / snake 2! 3 3 apple 2! 3 length !
  ['] up direction ! left step! left step! left step! left step! ;

: greet  ." Snake in Forth" ;
: delay  300 ms ;
: run    200 gameloop ;
: go  newgame! page greet delay run bye ;
