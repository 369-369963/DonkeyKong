using System.Diagnostics.Contracts;
using DxLibDLL;

class Game
{
    InputState GetCurrentInput() => new InputState
    {
        Jump = DX.CheckHitKey(DX.KEY_INPUT_UP) == 1,
        Right = DX.CheckHitKey(DX.KEY_INPUT_RIGHT) == 1,
        Left = DX.CheckHitKey(DX.KEY_INPUT_LEFT) == 1
    };

    public void Update()
    {
        InputState input = GetCurrentInput();
        Player.Update(input);
    }

    public void Render()
    {
        // 画面をクリア
        DX.ClearDrawScreen();
        // 文字を描画
        DX.DrawString(100, 100, "Hello World", DX.GetColor(255, 255, 255));
        // 裏画面の内容を表画面に反映
        DX.ScreenFlip();
    }

    public void Run()
    {
        // メインループ
        while (DX.ProcessMessage() == 0)
        {
            Update();
            Render();
        }
    }
}

struct InputState
{
    public bool Jump;
    public bool Right;
    public bool Left;
}

class Program
{
    static Program()
    {
        // ウィンドウモードで起動するように設定
        DX.ChangeWindowMode(DX.TRUE);

        // Dxlib の初期化
        DX.DxLib_Init();
        // 描画先を裏画面に設定
        DX.SetDrawScreen(DX.DX_SCREEN_BACK);
    }

    static void Main(string[] args)
    {
        // ゲームのインスタンスを作成
        Game game = new Game();
        // ゲームを実行
        game.Run();
        // Dxlib の終了処理
        DX.DxLib_End();
    }
}
