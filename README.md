# 障碍竞速

引擎原理课第三次作业。

一个障碍竞速小游戏，要在尽可能短的时间内跑完全程。

开发环境为Unity 2019.4，需要Cinemachine插件。

可执行文件在Build目录下，主场景在Assets\Scenes目录下。

## 玩法

使用WASD键或方向键控制角色和车辆移动，使用空格键控制角色跳跃。

当角色在车辆旁边时，使用T键上车。

使用Q键退出游戏，使用R键重新开始游戏。

注意，如果角色从赛道上掉落，或者被红色的球撞击，则会输掉游戏。

## 作业要求完成情况

### 运动体（Kinmetic body）

1. 角色不处于布娃娃状态时，布娃娃的各个组成部分都是运动刚体状态。
2. 第二层赛道的斜坡上的球在角色未上车时是运动刚体状态，在角色上车后解除运动刚体状态，开始受重力作用而向下滚动。

### 刚体（Rigidbody）：

1. 角色
2. 车辆
3. 赛道上的各种障碍物

### 关节（Joint）：

第一层赛道中的三个红色摆球使用了Hinge Joint，实现了摆动效果。

### 布娃娃（Ragdoll）：

角色被红色的球撞击时切换到布娃娃状态。

### 载具（Vehicle）：

第二层赛道上停了一辆赛车，角色上车后即可操控赛车。

### 代码整洁度：

见项目工程和脚本源码。

### 创意：

1. 赛道设计
2. 连接两层赛道的电梯