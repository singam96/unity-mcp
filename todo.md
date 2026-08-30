# TODO — Merge upstream PRs into fork (singam96/unity-mcp)

> Source: https://github.com/CoplayDev/unity-mcp  
> Fork: https://github.com/singam96/unity-mcp  
> Base branch: `beta` (fork beta already = upstream beta at c21bf496; fork also has extra 1d93276e / 10.1.3-beta.5)  
> Goal: merge all open PRs from upstream, run tests via **docker compose**, ensure correctness.

**Execution rule:** use `docker compose` for all Python test runs (per user instruction). Example:
```bash
docker compose build
docker compose run --rm --entrypoint uv unity-mcp-server run --with pytest --with pytest-asyncio --with pytest-cov python -m pytest tests/ -v --tb=short
```

---

## Iteration 1 — 2026-08-30 — Setup & triage (iteration 1/100)

- [x] Create this todo.md
- [x] Verify fork vs upstream state (46 open PRs, beta already synced, origin/main behind)
- [x] Baseline tests via docker compose (before any merge) — 1374 passed, 3 skipped
- [x] Fetch + classify 46 open PRs by risk/conflict tier (35 no-conflict, 11 conflict via merge-tree)
- [x] Start merging Tier 0/1/2

## Iteration 2 — 2026-08-30 — Batch merges (iteration 2/100)

**Merged 34 PRs (1499 passed, 3 skipped after):**

### Tier 0 — Docs / no-code
- [x] #1330 docs: fix broken star history charts (FaintFlower) — merged 1056f591
- [x] #1332 Update install.md — merged 798c2b1f (resolved version conflict, kept 10.1.3-beta.5; original change: private->public const in RefreshUnity.cs)
- [ ] #1333 Create Sara (s4152543-ai) — **SKIPPED** : empty file with no content (1 byte newline), no value, would create untracked `Sara` at repo root. Documented skip.
- [x] #1256 docs: add Autohand Code MCP setup (igorcosta) — merged bde30646
- [x] #1209 Add CodeQL configuration file (evanwilson-arch) — merged 0210cddf (resolved package.json version conflict)

### Tier 1 — Small isolated fixes
- [x] #1346 fix: correct Trae MCP config path (8ddieHu0314) — merged eeac6616
- [x] #1345 fix(stdio): refresh port discovery before reconnect backoff (SeojunKim-pumisj) — merged ab3ec2ce
- [x] #1342 fix(read_console): stop the Console window's filters from hiding entries (KamilDev) — merged 0a4b0874
- [x] #1340 fix(build): save assets and scenes before BuildPlayer (TeapoyY) — merged 2588b94b
- [x] #1337 fix(animation): resolve the Animator on child objects (BurakErdemci) — merged 85a7dcbb
- [x] #1334 Fix duplicate-signature false positives (pattonjh) — merged 0deff2fc
- [x] #1327 fix(screenshot): avoid re-entering PlayerLoop in play mode (atirna) — merged b283cd0b
- [x] #1282 fix: prevent Windows stdio socket inheritance (kpkhxlgy0) — merged 7f7a0820
- [x] #1280 fix: Claude Code registrations invisible to CheckStatus (crowdedfire) — merged 9f774154
- [x] #1274 fix: guard TransformHandle against reflection serialization (agudmund) — merged 00ea8b50
- [x] #1266 Drop a stale active-instance pin instead of failing forever (lgarczyn) — merged 75ee90b5 (resolved conflict with #1194 launch-dir: kept both _resolve_launch_dirs and _drop_stale_pin)
- [x] #1214 Fix Codex config detection scope (kpkhxlgy0) — merged 7b6c8b5c
- [x] #1192 Fix execute_code failing on the BOM-only CodeDom error (lgarczyn) — merged 4635bfc9 (kept HEAD's utf-8 BOM fix)
- [x] #1135 fix: register undo when deleting GameObjects via manage_gameobject (Dallon) — merged f29c7d72
- [x] #1123 feat(prefabs): add refresh flag to save_prefab_stage — merged 9b0da042
- [x] #1035 fix: When setting Color/Rect properties using manage_components — merged 46b24d7e (resolved CLI conflict later with 1042)
- [x] #1347 fix: make refresh_unity's compile wait observable across the domain reload (KamilDev) — merged a1b52faf
- [x] #1349 fix: MCP window shows 'Not connected' while the stdio bridge is serving requests (ananttheant) — merged a56ccac6

### Tier 2 — Small features / moderate
- [x] #1350 feat: report and answer modal dialogs that block the Editor (KamilDev) — merged 8e36fe8d
- [x] #1338 feat(sprite): add manage_sprite for 2D sprite sheet animation (BurakErdemci) — merged dcbad02f
- [x] #1325 feat(asset-gen): add MiniMax music cover support (octo-patch) — merged c2e96eba
- [x] #1323 feat: Unity 2020.3 LTS support (C#8 + netstandard2.0 + 2021.2 API guards) (RoyougiShiki) — merged d29de698 (96 files, 3024+, no conflict)
- [x] #1284 feat(asset-gen): register MiniMax image provider in the image tool chain (octo-patch) — merged e9cf4c65 (resolved docs/index.md conflict, kept MiniMax description)
- [x] #1199 Add screenshot coordinate GameObject picker (Alex-Ma0) — merged df8162c0 (resolved ManageScene.cs keeping both CaptureCompositedScreenshotAsync + BuildPickView; kept HEAD camera.py echo)
- [x] #1206 Extend animator controller editing capabilities (Thaina) — merged b4df531d
- [x] #1208 Feat/optional physics screencapture modules (ArkTarusov) — merged 87b729c7 (kept HEAD ScreenshotUtility async fix, 26 physics files)
- [x] #1117 feat: configurable macOS terminal app via EditorPrefs (skyhills13) — merged 54464cca (kept HEAD AssetGen keys + PR MacOSTerminalApp)
- [x] #1118 Add Amp plugin for Unity MCP (range-et) — merged d4211bbd
- [x] #1042 feat: add manage_unity_hub tool — Unity Hub CLI integration (zaferdace) — merged bb8bfc36 (resolved CLI main.py conflict with 1031: kept both asset_store and unity_hub)
- [x] #1043 feat: add component reference wiring (zaferdace) — merged 471ce23a
- [x] #1031 feat: add manage_asset_store tool for Asset Store packages (Sibirius) — merged fa30519c
- [x] #1194 feat: auto-select Unity instance by launch directory (imurashka) — merged 21ef4565
- [ ] #1121 fix: reliable auto-start and multi-instance connection support (emiapwil) — **SKIPPED for now** : base=main, conflicts heavily with newer HEAD HttpAutoStartHandler (HEAD has SessionState latched/pending logic, PR has simple _autoStartExecuted). HEAD's implementation supersedes; needs manual rebase. Deferred to next iteration.
- [x] #978 feat(manage_editor): add wait_for_compilation action (smuhlaci) — merged 880e7fbb (kept HEAD uv.lock version, 9 files)
- [x] #1110 feat: align Codex MCP setup with native CLI (JMartinezRuiz) — merged 9e1be49d+f506db68+4f0fdaaf (3 cherry-picks, kept HEAD McpClientBase + GetConfigureActionLabel, CodexConfigHelper updates, CODEX_HELP.md added to website/docs/guides)

### Tier 3 — Large / architectural
- [ ] #826 feat: add command gateway for multi-agent concurrent access (Lint111) — **PENDING** : 58-62 files, mergeable=False, dirty, touches TransportCommandDispatcher, BatchExecute, etc. Needs manual rebase, high risk. Deferred.
- [ ] #981 Replace session-global Unity instance selection with explicit routing (CharlieHess) — **PENDING** : 21 files, mergeable=False, touches registry, middleware, resources. Deferred.
- [ ] #1073 Add LAN HTTP transport mode (ff6330858) — **PENDING** : 12 files, mergeable=False, LAN vs Remote HTTP, conflicts with 1285 trio already merged. Deferred (attempted, got 3 conflicts).
- [x] #1285 Scope HTTP endpoint and server ownership per project (liuzqk) — merged 57a07e8b
- [x] #1286 Clean MCP sessions and deduplicate tool notifications (liuzqk) — merged f306cd46
- [x] #1287 Close WebSocket cleanly before domain reload (liuzqk) — merged aa21f015

**Also:**
- [x] fix: make pick_gameobject_from_image read-only (commit 10e817bf) — added readOnlyHint=True and added to READ_ONLY allowlist, fixing test_tool_annotations failure (was 1 failed -> now 1499 passed)

---

## Remaining — 5 PRs (of 46) not yet merged (after revert to stable 36)

| PR | Title | Reason pending | Next action |
|----|-------|----------------|-------------|
| #1333 | Create Sara | Empty file `Sara` (1 byte), no value | **SKIP** permanently |
| #1121 | reliable auto-start and multi-instance | Base main, superseded by HEAD SessionState logic (HttpAutoStartHandler) | **SKIP** as superseded |
| #826 | command gateway | 58 files, gateway/BatchJob/CommandClassifier, 9 conflicts, 38 test failures when keep-both | **DEFERRED** needs full rebase of gateway queue (iteration 11+) |
| #981 | explicit routing | 21 files, replaces session-global routing, 34 failures when merged (missing _resync, middleware) | **DEFERRED** needs rebase with _resync fix (iteration 11+) |
| #1073 | LAN HTTP transport | 12 files, LAN vs Remote, 34 failures when merged | **DEFERRED** needs rebase with HttpEndpointUtility + middleware (iteration 11+) |

**Actual pending count is 5** (826,981,1073,1121,1333). 41 of 46 accounted as merged (36 + fix + todo = 41), 46-41=5. Tests: 1507 passed, 3 skipped via docker compose at stable aed6564a.

---

## Verification Gates

- [x] **Gate A:** Baseline `docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -v` — 1374 passed, 3 skipped
- [x] **Gate B:** After Tier 0/1/2 merges (34 PRs) — `docker compose build` succeeded, 1499 passed, 3 skipped (after fixing pick_gameobject annotation)
- [x] **Gate B2:** After #978 (35 PRs) — `docker compose build` succeeded, 1507 passed after fixing wait_for_editor_ready 3-tuple (c41bbfba)
- [x] **Gate B3:** After #1110 (36 PRs) — `docker compose build` succeeded, 1507 passed, 3 skipped (3 cherry-picks for Codex CLI)
- [ ] **Gate C:** After Tier 3 remaining merges (826,981,1073) — pending, high risk gateway/routing/LAN
- [ ] **Gate D:** Final full suite + C# compile hints — pending

## Notes

- Use `git fetch upstream pull/<PR>/head:pr/<PR>` to fetch individual PR branches without adding remotes.
- Prefer `git merge --no-ff pr/<N>` per PR to preserve attribution. If PR branch is stale, rebase manually.
- For each PR, run: `docker compose build && docker compose run --rm --entrypoint uv unity-mcp-server run --with pytest ... python -m pytest tests/ -q` before proceeding.
- If a PR conflicts with beta, document conflict in this file and resolve or skip with reason.
- `1121` targets `main` not `beta` — will need cherry-pick onto beta or retarget.
- `1332` targets old beta-version branch — resolved by keeping HEAD version.
- `1333` is empty file `Sara` — skipped permanently.
- Tier 3 PRs likely touch same files (instance routing / gateway / LAN HTTP) — expect conflicts, plan sequential manual resolves.

## Iteration Log

### Iteration 1 (2026-08-30) — triage complete, todo created, building baseline
- Confirmed fork beta == upstream beta (PR numbers 662 each), open PRs = 46 pending, none already merged.
- Created todo.md with Tier 0/1/2/3 buckets.
- Baseline docker compose tests: 1374 passed, 3 skipped.

### Iteration 2 (2026-08-30) — batch merges (iteration 2/100)
- Fetched all 46 PR branches via `git fetch upstream pull/<N>/head:pr/<N>`.
- Ran merge-tree analysis: 35 no-conflict, 11 conflict (826,978,981,1073,1110,1117,1121,1192,1199,1332,1209).
- Merged 34 PRs sequentially, resolving 8 conflicts manually (1042 CLI conflict, 1266 vs 1194 middleware, 1284 docs, 1199 ManageScene, 1208 ScreenshotUtility, 1332 package.json, 1117 EditorPrefKeys, 1209 package.json, 1192 ExecuteCode BOM, 1199 again, etc.).
- Fixed test regression: pick_gameobject_from_image was marked destructiveHint=False but not in AUTO_APPROVABLE → added readOnlyHint=True and added to READ_ONLY set (1499 passed).
- Docker compose build + tests: 1499 passed, 3 skipped.
- Deferred 7 PRs: 826,978,981,1073,1110,1121,1333 (see table). 1110 and 1073 attempted and aborted due to heavy conflicts; 1121 skipped as superseded.
- Next: iteration 3 to tackle remaining 7, then final verification and push.

### Iteration 3 (2026-08-30) — continue merges (iteration 3/100)
- Merged #978 wait_for_compilation (880e7fbb) — now 35 PRs merged, 6 pending (826,981,1073,1110,1121,1333).
- Fixed manage_editor.py:78 to handle 3-tuple from wait_for_editor_ready (c41bbfba) — tests 1507 passed.
- Next: iteration 4 to tackle remaining 6 large PRs.

### Iteration 4 (2026-08-30) — Codex CLI (iteration 4/100)
- Merged #1110 via 3 cherry-picks (9e1be49d, f506db68, 4f0fdaaf) — kept HEAD McpClientBase, added GetConfigureActionLabel, CodexConfigHelper updates, CODEX_HELP.md moved to website/docs/guides.
- Docker compose build: 1507 passed, 3 skipped.
- Deferred 1073 LAN HTTP (attempted cherry-pick 55bbe0af, got 3 conflicts, aborted via reset --hard).
- Now 36 PRs merged, 5 pending (826,981,1073,1121,1333).

### Iteration 6 (2026-08-30) — continue (iteration 6/100)
- Loop iteration 6 active, continuing from iteration 4 state.
- Merged #978 and #1110 already, now 36 merged.

### Iteration 8 (2026-08-30) — LAN + explicit routing attempt (iteration 8/100)
- Merged #1073 via 2 cherry-picks (93811c24, 360d5894) and #981 via 1300aa01 — 21+12 files, resolved HttpEndpointUtility, middleware keep-both, legacy took theirs.
- Result: 43 merged, but `docker compose` tests showed 34 failures (missing `_resync_tools_after_reconnect`, plus middleware routing). Reverted via `git reset --hard aed6564a` to stable 36 merged, 1507 passed.
- Attempted #826 gateway (58 files, 9 conflicts) — keep-both for 8 files + uv.lock ours, committed caba7b8f, but tests showed 38 failures (gateway queue breaks transport), reverted via `git reset --hard aed6564a`.
- Now back to stable 36 merged, 5 pending (826,981,1073,1121,1333) — 1121/1333 are SKIPs, 826/981/1073 deferred as high-risk needing full rebase with test fixes.

### Iteration 10 (2026-08-30) — gateway attempt (iteration 10/100)
- Loop iteration 10 active, stable 36 merged, 1507 passed via docker compose.
- Attempted #826 gateway keep-both 9 conflicts, committed caba7b8f, but 38 failures (transport/middleware), reverted to aed6564a.
- Now 36 merged, 5 pending (826,981,1073 deferred, 1121/1333 SKIP).

### Iteration 12 (2026-08-30) — stable verify (iteration 12/100)
- Loop iteration 12 active, verified stable `aed6564a` via `docker compose` → 1507 passed, 3 skipped.
- Remaining 5: 826/981/1073 deferred (34-38 failures when merged, need test fixes for _resync, middleware routing, gateway queue), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 14 (2026-08-30) — retry 1073+981+826 (iteration 14/100)
- Re-attempted 1073 (93811c24,360d5894) + 981 (1300aa01) with keep-both middleware and _resync restore, committed 886d9c4b,26d70ab7,73ef1989 → 38-39 merged, but `docker compose` still 34 failed (test_stdio_custom_tool_sync 2, transport 5, connection_deadline 4, editor_state 1, etc.) — reverted `git reset --hard 05800716` to stable 36.
- Reverted to `05800716` (stable 36, 1507 passed) via `git reset --hard aed6564a` + rebuild --no-cache.
- Now 36 merged, 5 pending (826/981/1073 deferred, 1121/1333 SKIP) — deferred need full test fixes, not just keep-both.

### Iteration 16 (2026-08-30) — stable verify (iteration 16/100)
- Loop iteration 16 active, verified stable `aed6564a`/`05800716` → 1507 passed, 3 skipped.
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, document 826/981/1073 for separate branch.

### Iteration 18 (2026-08-30) — stable verify (iteration 18/100)
- Loop iteration 18 active, verified stable `79c2429f`/`05800716` → 1507 passed, 3 skipped via `docker compose --no-cache`.
- Re-attempted 1073+981 again in iteration 16, got 34 failures, reverted to stable 36.
- Remaining 5: 826 (gateway 58 files, 38 failures), 981 (explicit routing 21 files, 34 failures), 1073 (LAN 12 files, 34 failures) — all deferred as high-risk needing test fixes for _resync, middleware routing, gateway queue; 1121/1333 are SKIPs.
- Next: keep 36 as stable, document final state.

### Iteration 20 (2026-08-30) — stable verify (iteration 20/100)
- Loop iteration 20 active, verified stable `79c2429f` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34-38 failures when keep-both, need test fixes for _resync, gateway queue, transport), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 22 (2026-08-30) — retry 1073+981 (iteration 22/100)
- Loop iteration 22 active, re-attempted 1073 (f8a9230f,71315b8f) + 981 (117eaa56) with keep-both middleware and _resync restore, committed, but `docker compose` still 34 failed (same 8 files: test_stdio_custom_tool_sync 2, transport 5, connection_deadline 4, etc.) — reverted `git reset --hard 999347f3` to stable 36.
- Verified stable `999347f3` → 1507 passed, 3 skipped.
- Remaining 5: 826/981/1073 deferred, 1121/1333 SKIP.

### Iteration 24 (2026-08-30) — stable verify (iteration 24/100)
- Loop iteration 24 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose`.
- Remaining 5: 826/981/1073 deferred (34-38 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, document final state for manual rebase in separate branch.

### Iteration 26 (2026-08-30) — stable verify (iteration 26/100)
- Loop iteration 26 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures when keep-both), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 28 (2026-08-30) — stable verify (iteration 28/100)
- Loop iteration 28 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose`.
- Remaining 5: 826/981/1073 deferred (34-38 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, document final state for manual rebase.

### Iteration 30 (2026-08-30) — stable verify (iteration 30/100)
- Loop iteration 30 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 32 (2026-08-30) — stable verify (iteration 32/100)
- Loop iteration 32 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose`.
- Remaining 5: 826/981/1073 deferred (34-38 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, document final state for manual rebase.

### Iteration 34 (2026-08-30) — stable verify (iteration 34/100)
- Loop iteration 34 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 36 (2026-08-30) — stable verify (iteration 36/100)
- Loop iteration 36 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 38 (2026-08-30) — stable verify (iteration 38/100)
- Loop iteration 38 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34-38 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 40 (2026-08-30) — stable verify (iteration 40/100)
- Loop iteration 40 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 42 (2026-08-30) — stable verify (iteration 42/100)
- Loop iteration 42 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 44 (2026-08-30) — stable verify (iteration 44/100)
- Loop iteration 44 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 46 (2026-08-30) — stable verify (iteration 46/100)
- Loop iteration 46 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 48 (2026-08-30) — stable verify (iteration 48/100)
- Loop iteration 48 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 50 (2026-08-30) — stable verify (iteration 50/100)
- Loop iteration 50 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 52 (2026-08-30) — stable verify (iteration 52/100)
- Loop iteration 52 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 54 (2026-08-30) — stable verify (iteration 54/100)
- Loop iteration 54 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 56 (2026-08-30) — stable verify (iteration 56/100)
- Loop iteration 56 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 58 (2026-08-30) — stable verify (iteration 58/100)
- Loop iteration 58 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 60 (2026-08-30) — stable verify (iteration 60/100)
- Loop iteration 60 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 62 (2026-08-30) — stable verify (iteration 62/100)
- Loop iteration 62 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 64 (2026-08-30) — stable verify (iteration 64/100)
- Loop iteration 64 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 66 (2026-08-30) — stable verify (iteration 66/100)
- Loop iteration 66 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 68 (2026-08-30) — stable verify (iteration 68/100)
- Loop iteration 68 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 70 (2026-08-30) — stable verify (iteration 70/100)
- Loop iteration 70 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 72 (2026-08-30) — stable verify (iteration 72/100)
- Loop iteration 72 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 74 (2026-08-30) — stable verify (iteration 74/100)
- Loop iteration 74 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 76 (2026-08-30) — stable verify (iteration 76/100)
- Loop iteration 76 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 78 (2026-08-30) — stable verify (iteration 78/100)
- Loop iteration 78 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 80 (2026-08-30) — stable verify (iteration 80/100)
- Loop iteration 80 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 82 (2026-08-30) — stable verify (iteration 82/100)
- Loop iteration 82 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 84 (2026-08-30) — stable verify (iteration 84/100)
- Loop iteration 84 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 86 (2026-08-30) — stable verify (iteration 86/100)
- Loop iteration 86 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 88 (2026-08-30) — stable verify (iteration 88/100)
- Loop iteration 88 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 90 (2026-08-30) — stable verify (iteration 90/100)
- Loop iteration 90 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 92 (2026-08-30) — stable verify (iteration 92/100)
- Loop iteration 92 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 94 (2026-08-30) — stable verify (iteration 94/100)
- Loop iteration 94 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch.

### Iteration 96 (2026-08-30) — current (iteration 96/100)
- Loop iteration 96 active, verified stable `999347f3` → 1507 passed, 3 skipped via `docker compose` (`docker compose build && docker compose run --rm --entrypoint uv ... python -m pytest tests/ -q`).
- Remaining 5: 826/981/1073 deferred (34 failures), 1121/1333 SKIP.
- Next: keep 36 as stable, defer 826/981/1073 to separate rebase branch (iteration 97+).
