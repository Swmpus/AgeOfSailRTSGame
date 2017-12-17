if keyboard_check(vk_enter)
{
    if room_next(room) != -1
    {
        room_goto(room_next(room));
    }
}
