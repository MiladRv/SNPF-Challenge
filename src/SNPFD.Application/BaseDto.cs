namespace SNPFD.Application;

public abstract record BaseDto<TId>(TId Id) 
    where TId : struct;