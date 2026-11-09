if(NOT TARGET game-activity::game-activity)
add_library(game-activity::game-activity STATIC IMPORTED)
set_target_properties(game-activity::game-activity PROPERTIES
    IMPORTED_LOCATION "C:/Users/penda/.gradle/caches/8.13/transforms/bbd31d9de896f3b2d29af762e8b4b63c/transformed/jetified-games-activity-4.4.0/prefab/modules/game-activity/libs/android.arm64-v8a/libgame-activity.a"
    INTERFACE_INCLUDE_DIRECTORIES "C:/Users/penda/.gradle/caches/8.13/transforms/bbd31d9de896f3b2d29af762e8b4b63c/transformed/jetified-games-activity-4.4.0/prefab/modules/game-activity/include"
    INTERFACE_LINK_LIBRARIES ""
)
endif()

if(NOT TARGET game-activity::game-activity_static)
add_library(game-activity::game-activity_static STATIC IMPORTED)
set_target_properties(game-activity::game-activity_static PROPERTIES
    IMPORTED_LOCATION "C:/Users/penda/.gradle/caches/8.13/transforms/bbd31d9de896f3b2d29af762e8b4b63c/transformed/jetified-games-activity-4.4.0/prefab/modules/game-activity_static/libs/android.arm64-v8a/libgame-activity_static.a"
    INTERFACE_INCLUDE_DIRECTORIES "C:/Users/penda/.gradle/caches/8.13/transforms/bbd31d9de896f3b2d29af762e8b4b63c/transformed/jetified-games-activity-4.4.0/prefab/modules/game-activity_static/include"
    INTERFACE_LINK_LIBRARIES ""
)
endif()

